"use strict";

Object.defineProperty(exports, "__esModule", {
  value: true
});

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

var RequestContext = exports.RequestContext = function RequestContext() {
  _classCallCheck(this, RequestContext);

  this.Case = arguments[0];
  this.Fields = [];

  for (var i = 1; i < arguments.length; i++) {
    this.Fields[i - 1] = arguments[i];
  }
};

var RequestMode = exports.RequestMode = function RequestMode() {
  _classCallCheck(this, RequestMode);

  this.Case = arguments[0];
  this.Fields = [];

  for (var i = 1; i < arguments.length; i++) {
    this.Fields[i - 1] = arguments[i];
  }
};

var RequestCredentials = exports.RequestCredentials = function RequestCredentials() {
  _classCallCheck(this, RequestCredentials);

  this.Case = arguments[0];
  this.Fields = [];

  for (var i = 1; i < arguments.length; i++) {
    this.Fields[i - 1] = arguments[i];
  }
};

var RequestCache = exports.RequestCache = function RequestCache() {
  _classCallCheck(this, RequestCache);

  this.Case = arguments[0];
  this.Fields = [];

  for (var i = 1; i < arguments.length; i++) {
    this.Fields[i - 1] = arguments[i];
  }
};

var ResponseType = exports.ResponseType = function ResponseType() {
  _classCallCheck(this, ResponseType);

  this.Case = arguments[0];
  this.Fields = [];

  for (var i = 1; i < arguments.length; i++) {
    this.Fields[i - 1] = arguments[i];
  }
};

var Globals = exports.Globals = function ($exports) {
  var Promise = $exports.Promise = function ($exports) {
    var either = $exports.either = function (a, b, pr) {
      return pr.then(a, b);
    };

    var lift = $exports.lift = function (a) {
      return Promise.resolve(a);
    };

    return $exports;
  }({});

  return $exports;
}({});

var PromiseBuilder = exports.PromiseBuilder = function PromiseBuilder() {
  _classCallCheck(this, PromiseBuilder);
};

var PromiseBuilderImp = exports.PromiseBuilderImp = function ($exports) {
  var promise = $exports.promise = new PromiseBuilder();
  return $exports;
}({});