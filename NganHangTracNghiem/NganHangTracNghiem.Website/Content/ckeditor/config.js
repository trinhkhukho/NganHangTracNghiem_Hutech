/**
 * @license Copyright (c) 2003-2017, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see LICENSE.md or http://ckeditor.com/license
 */

CKEDITOR.editorConfig = function (config) {


    // Define changes to default configuration here. For example:
     //config.language = 'fr';
    //config.uiColor = '#AADC6E';
    //nó put vô mà sao ko lưu đc

    config.height = 100;
    config.language = 'en';
    config.uiColor = '#EDEDED';
    config.extraPlugins = 'widget,html5audio,eqneditor';//loadding/audio/latex
    config.toolbar = [
        { name: 'insert', items: ['Image', 'Table', 'SpecialChar', 'EqnEditor', 'Html5audio'] },
        { name: 'basicstyles', groups: [ 'basicstyles', 'cleanup' ], items: [ 'Bold', 'Italic', 'Strike' ] },
        { name: 'paragraph', groups: [ 'list', 'indent', 'blocks', 'align', 'bidi' ], items: [ 'NumberedList', 'BulletedList', '-', 'Outdent', 'Indent', '-', 'Blockquote' ] },
        { name: 'styles', items: [ 'Format', 'Font', 'FontSize'] },
     
    ];


};
