/**
 * @license Copyright (c) 2003-2017, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see LICENSE.md or http://ckeditor.com/license
 */

CKEDITOR.editorConfig = function (config) {


    // Define changes to default configuration here. For example:
     //config.language = 'fr';
     //config.uiColor = '#AADC6E';


    config.height = 100;
    config.language = 'en';
    config.uiColor = '#EDEDED';
    config.extraPlugins = 'widget';//audio need
    config.extraPlugins = 'eqneditor';//late
    config.extraPlugins = 'html5audio';//audio

    config.toolbar = [

        { name: 'insert', items: ['Image', 'Html5audio', 'Table', 'SpecialChar', 'EqnEditor'] },
        //{ name: 'others', items: [ '-' ] },
        //'/',
        { name: 'basicstyles', groups: [ 'basicstyles', 'cleanup' ], items: [ 'Bold', 'Italic', 'Strike', '-', 'RemoveFormat' ] },
        { name: 'paragraph', groups: [ 'list', 'indent', 'blocks', 'align', 'bidi' ], items: [ 'NumberedList', 'BulletedList', '-', 'Outdent', 'Indent', '-', 'Blockquote' ] },
        { name: 'styles', items: ['Styles', 'Format', 'Font', 'FontSize'] },
     
    ];


};
