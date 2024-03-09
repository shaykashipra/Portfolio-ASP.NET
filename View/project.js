"use strict";

/////////////////////////////////////////////////////
// Function for adding event on multiple element ////
/////////////////////////////////////////////////////
const addEventOnElements = function (elements, eventType, callback) {
  // for(let i=0;i<elements.length;i++){
  //     elements[i].addEventListener(eventType,callback);

  // }
  //use for each
  elements.foreach(function (element) {
    element.addEventListener(eventType, callback);
  });
};

///////////////////////////////////////////////////////
// PRELOADING//////////////////////////////////////////
///////////////////////////////////////////////////////

const loadingElement = document.querySelector("[data-loading]");

window.addEventListener("load", function () {
  loadingElement.classList.add("loaded");
  this.document.body.classList.remove("active");
});



////////////////////////////////////////////////////////
///////////     Show Projects   ////////////////////////
////////////////////////////////////////////////////////

function showProjects(topic) {
  var allContent = document.querySelectorAll("#projectContent > ul");

  var buttons = document.querySelectorAll(".button-projects");
  buttons.forEach(function (button) {
    button.classList.remove("selected");
  });

  if (topic === "Allp") {
    allContent.forEach(function (content) {
      content.style.display = "block";
    });
    document.getElementById("btnAllp").classList.add("selected");
  } else {
    allContent.forEach(function (content) {
      if (content.id === "pr" + topic) {
        content.style.display = "block";
        document.getElementById("btn" + topic).classList.add("selected");
      } else if (content.id === "prBoth") {
        content.style.display = "block";
        document.getElementById("btn" + topic).classList.add("selected");
      } else {
        content.style.display = "none";
      }
    });
  }
}
