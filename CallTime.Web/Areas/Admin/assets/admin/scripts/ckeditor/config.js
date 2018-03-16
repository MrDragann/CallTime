/**
 * @license Copyright (c) 2003-2015, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see LICENSE.md or https://ckeditor.com/license
 */

CKEDITOR.editorConfig = function (config) {
    // Define changes to default configuration here. For example:
    // config.language = 'fr';
    config.toolbar = 'FULL';
    config.font_names = 'Roboto; Palatino Linotype;Calibri;Candara;Myriad;Arial/Arial, sans-serif;Comic Sans MS/Comic Sans MS, cursive;Courier New/Courier New, Courier, monospace;Georgia/Georgia, serif;Lucida Sans Unicode/Lucida Sans Unicode, Lucida Grande, sans-serif;Tahoma/Tahoma, Geneva, sans-serif;Times New Roman/Times New Roman, Times, serif;Trebuchet MS/Trebuchet MS, sans-serif;Verdana/Verdana, Geneva, sans-serif';
    config.uiColor = '#0ba5bc';
    config.skin = 'moono';
    config.filebrowserUploadUrl = '/cll/api/v1/storage/upload';
    config.language = 'ru';
    config.extraPlugins = 'popup';
    config.extraPlugins = 'onchange';
    config.protectedSource.push(/<script[\s\S]*?script>/g); /* script tags */
    config.allowedContent = true; /* all tags */
    config.forcePasteAsPlainText = true;
    config.scayt_autoStartup = false;
    config.disableNativeSpellChecker = false;
    config.extraPlugins = 'sourcedialog';
    config.removePlugins = 'scayt';
    config.inlinesave = {
        postUrl: '/cll/api/v1/staticContent',
        //postData: { text: true },
        onSave: function (dialog1) { console.log('save successful', dialog1); return true; },
        onSuccess: function (dialog1, data) { console.log('save successful', dialog1, data); },
        onFailure: function (dialog1, status, request) { console.log('save failed', dialog1, status, request); },
        useJSON: true,
        useColorIcon: true
    };
};