'use strict'


/////////////////////////////////////////////////////
// Function for adding event on multiple element ////
/////////////////////////////////////////////////////
const addEventOnElements = function(elements,eventType,callback){
        // for(let i=0;i<elements.length;i++){
        //     elements[i].addEventListener(eventType,callback);
      
        // }
        //use for each
        elements.foreach(function(element){
                element.addEventListener(eventType,callback);
        });
}

///////////////////////////////////////////////////////
// PRELOADING//////////////////////////////////////////
///////////////////////////////////////////////////////

const loadingElement = document.querySelector("[data-loading]");

 window.addEventListener("load",function(){
    loadingElement.classList.add("loaded");
    this.document.body.classList.remove("active");
 });



// window.addEventListener("load", function () {
//     // this.setTimeout(function (){
//   loadingElement.classList.add("loaded");
//   document.body.classList.remove("active");
// // },2000);
//  });



// // call the letter effect function after window loaded
// window.addEventListener("load", setLetterEffect);


///////////////////////////////////////////////////////////
// Text Animation Effect//////////////////////////////////
///////////////////////////////////////////////////////////

const letterBoxes = document.querySelectorAll("[data-letter-effect]");

let activeLetterBoxIndex = 0;
let lastActiveLetterBoxIndex = 0;
let totalLetterBoxDelay = 0;




const setLetterEffect = function () {
  // loop through all letter boxes

  for (let i = 0; i < letterBoxes.length; i++) {
    // set initial animation delay
    let letterAnimationDelay = 0;

    // get all character from the current letter box
    const letters = letterBoxes[i].textContent.trim();
    // remove all character from the current letter box
    letterBoxes[i].textContent = "";

    // loop through all letters
    for (let j = 0; j < letters.length; j++) {
      // create a span
      const span = document.createElement("span");

      // set animation delay on span
      span.style.animationDelay = `${letterAnimationDelay}s`;

      // set the "in" class on the span, if current letter box is active
      // otherwise class is "out"
      if (i === activeLetterBoxIndex) {
        span.classList.add("in");
      } else {
        span.classList.add("out");
      }

      // pass current letter into span
      span.textContent = letters[j];

      // add space class on span, when current letter contain space
      if (letters[j] === " ") span.classList.add("space");

      // pass the span on current letter box
      letterBoxes[i].appendChild(span);

      // skip letterAnimationDelay when loop is in the last index
      if (j >= letters.length - 1) break;
      // otherwise update
      letterAnimationDelay += 0.05;
    }

    // get total delay of active letter box
    if (i === activeLetterBoxIndex) {
      totalLetterBoxDelay = Number(letterAnimationDelay.toFixed(2));
    }

    // add active class on last active letter box
    if (i === lastActiveLetterBoxIndex) {
      letterBoxes[i].classList.add("active");
    } else {
      letterBoxes[i].classList.remove("active");
    }
  }

  setTimeout(function () {
    lastActiveLetterBoxIndex = activeLetterBoxIndex;

    // update activeLetterBoxIndex based on total letter boxes
    activeLetterBoxIndex >= letterBoxes.length - 1
      ? (activeLetterBoxIndex = 0)
      : activeLetterBoxIndex++;

    setLetterEffect();
  }, totalLetterBoxDelay * 1000 + 3000);
};

// call the letter effect function after window loaded
window.addEventListener("load", setLetterEffect);


/**
 * BACK TO TOP BUTTON
 */

const backTopBtn = document.querySelector("[data-back-top-btn]");

window.addEventListener("scroll", function () {
  const bodyHeight = document.body.scrollHeight;
  const windowHeight = window.innerHeight;
  const scrollEndPos = bodyHeight - windowHeight;
  const totalScrollPercent = (window.scrollY / scrollEndPos) * 100;

  backTopBtn.textContent = `${totalScrollPercent.toFixed(0)}%`;

  // visible back top btn when scrolled 5% of the page
  if (totalScrollPercent > 5) {
    backTopBtn.classList.add("show");
  } else {
    backTopBtn.classList.remove("show");
  }
});



/**
 * SCROLL REVEAL  , photography category show,reveal element
 */

const revealElements = document.querySelectorAll("[data-reveal]");

const scrollReveal = function () {
  for (let i = 0; i < revealElements.length; i++) {
    const elementIsInScreen = revealElements[i].getBoundingClientRect().top < window.innerHeight / 1.15;

    if (elementIsInScreen) {
      revealElements[i].classList.add("revealed");
    } else {
      revealElements[i].classList.remove("revealed");
    }
  }
}

window.addEventListener("scroll", scrollReveal);

scrollReveal();

/**
 * CUSTOM CURSOR
 */

const cursor = document.querySelector("[data-cursor]");
const anchorElements = document.querySelectorAll("a");
const buttons = document.querySelectorAll("button");

// change cursorElement position based on cursor move
document.body.addEventListener("mousemove", function (event) {
  setTimeout(function () {
    cursor.style.top = `${event.clientY}px`;
    cursor.style.left = `${event.clientX}px`;
  }, 100);
});

// add cursor hoverd class
const hoverActive = function () { cursor.classList.add("hovered"); }

// remove cursor hovered class
const hoverDeactive = function () { cursor.classList.remove("hovered"); }

// add hover effect on cursor, when hover on any button or hyperlink
addEventOnElements(anchorElements, "mouseover", hoverActive);
addEventOnElements(anchorElements, "mouseout", hoverDeactive);
addEventOnElements(buttons, "mouseover", hoverActive);
addEventOnElements(buttons, "mouseout", hoverDeactive);

// add disabled class on cursorElement, when mouse out of body
document.body.addEventListener("mouseout", function () {
  cursor.classList.add("disabled");
});

// remove diabled class on cursorElement, when mouse in the body
document.body.addEventListener("mouseover", function () {
  cursor.classList.remove("disabled");
});




// // Function to update skill bar width based on percentage
// function updateSkillBarWidth(skillBar) {
//     console.log("Updating skill bar width...");
//     // Get the percentage text from the skill bar
//     const percentageText = skillBar.querySelector('.info-skill p:nth-child(2)').innerText;
//     console.log("Percentage text:", percentageText);
//     // Convert the percentage text to a number
//     const percentage = parseInt(percentageText);
//     console.log("Percentage:", percentage);
//     // Set the width of the skill bar based on the percentage
//     const infoBar = skillBar.querySelector('.info-bar span');
//     console.log("Info bar:", infoBar);
//     infoBar.style.width = `${percentage}%`;
// }

// // Get all skill bars
// const skillBars = document.querySelectorAll('.skill-bar');
// console.log("Skill bars:", skillBars);

// // Loop through each skill bar and call the updateSkillBarWidth function
// skillBars.forEach(updateSkillBarWidth);

// Function to check if an element is in the viewport
// function isInViewport(element) {
//     const rect = element.getBoundingClientRect();
//     return (
//         rect.top >= 0 &&
//         rect.left >= 0 &&
//         rect.bottom <= (window.innerHeight || document.documentElement.clientHeight) &&
//         rect.right <= (window.innerWidth || document.documentElement.clientWidth)
//     );
// }

// // Function to handle scroll event
// function handleScroll() {
//     // Get all elements with class "info-bar"
//     const infoBars = document.querySelectorAll('.info-bar');

//     // Loop through each info bar
//     infoBars.forEach(infoBar => {
//         // Check if the info bar is in the viewport
//         if (isInViewport(infoBar)) {
//             // Add a class to trigger the animation
//             infoBar.classList.add('animate');
//         }
//     });
// }

// // Add event listener for scroll event
// window.addEventListener('scroll', handleScroll);


// /////////////////////////////
 //  Circle skill //////////////
////////////////////////////////
////////////////////////////////


// const circles=document.querySelectorAll('.circle');
// circles.forEach(elem=>{

//   var dots= elem.getAttribute("data-dots");
//   var marked=elem.getAttribute("data-percent");
//   var percent= Math.floor(dots*marked/100);

//   var points="";
//   var rotate=360/dots;

//   for(let i=0;i<dots;i++){
//     points += `<div class="percent" style="--i:${i}; --rot:${rotate}deg"></div>`;
//   }

//   elem.innerHTML=points;

//   const pointsMarked=elem.querySelectorAll('.points');
//   for(let i=0;i<percent;i++){
//     pointsMarked[i].add('marked');
//   }
// })