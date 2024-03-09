'use strict'

///////////////////////////////////////////////////////
// PRELOADING//////////////////////////////////////////
///////////////////////////////////////////////////////

const loadingElement = document.querySelector("[data-loading]");

window.addEventListener("load", function () {
  loadingElement.classList.add("loaded");
  this.document.body.classList.remove("active");
});
