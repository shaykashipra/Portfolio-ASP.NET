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
