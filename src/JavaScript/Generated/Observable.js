"use strict";

Object.defineProperty(exports, "__esModule", {
  value: true
});

var _createClass = function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; }();

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

var Console = exports.Console = function ($exports) {
  return $exports;
}({});

var Json = exports.Json = function ($exports) {
  return $exports;
}({});

var Observable = exports.Observable = function ($exports) {
  var Globals = $exports.Globals = function () {
    function Globals() {
      _classCallCheck(this, Globals);
    }

    _createClass(Globals, null, [{
      key: "observable",
      get: function () {
        throw "JS only";
      },
      set: function (v) {
        throw "JS only";
      }
    }]);

    return Globals;
  }();

  return $exports;
}({});