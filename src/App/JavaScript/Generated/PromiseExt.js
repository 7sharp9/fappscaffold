"use strict";

Object.defineProperty(exports, "__esModule", {
  value: true
});

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

var Promise = exports.Promise = function ($exports) {
  var fail = $exports.fail = function (a, pr) {
    return pr.catch(a);
  };

  var either = $exports.either = function (a, b, pr) {
    return pr.then(a, b);
  };

  var lift = $exports.lift = function (a) {
    return Promise.resolve(a);
  };

  return $exports;
}({});

var PromiseBuilder = exports.PromiseBuilder = function PromiseBuilder() {
  _classCallCheck(this, PromiseBuilder);
};

var PromiseBuilderImp = exports.PromiseBuilderImp = function ($exports) {
  var promise = $exports.promise = new PromiseBuilder();
  return $exports;
}({});