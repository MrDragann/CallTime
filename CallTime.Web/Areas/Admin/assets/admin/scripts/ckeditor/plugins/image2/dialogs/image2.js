﻿/*
 Copyright (c) 2003-2016, CKSource - Frederico Knabben. All rights reserved.
 For licensing, see LICENSE.md or https://ckeditor.com/license
*/
CKEDITOR.dialog.add("image2",function(k){function D(){var a=this.getValue().match(E);(a=!(!a||0===parseInt(a[1],10)))||alert(c["invalid"+CKEDITOR.tools.capitalize(this.id)]);return a}function O(){function a(a,b){d.push(l.once(a,function(a){for(var l;l=d.pop();)l.removeListener();b(a)}))}var l=t.createElement("img"),d=[];return function(d,b,c){a("load",function(){var a=F(l);b.call(c,l,a.width,a.height)});a("error",function(){b(null)});a("abort",function(){b(null)});l.setAttribute("src",(x.baseHref||
"")+d+"?"+Math.random().toString(16).substring(2))}}function G(){var a=this.getValue();u(!1);a!==y.data.src?(H(a,function(a,d,b){u(!0);if(!a)return m(!1);g.setValue(!1===k.config.image2_prefillDimensions?0:d);h.setValue(!1===k.config.image2_prefillDimensions?0:b);v=d;w=b;m(I.checkHasNaturalRatio(a))}),n=!0):n?(u(!0),g.setValue(p),h.setValue(q),n=!1):u(!0)}function J(){if(e){var a=this.getValue();if(a&&(a.match(E)||m(!1),"0"!==a)){var b="width"==this.id,d=p||v,c=q||w,a=b?Math.round(a/d*c):Math.round(a/
c*d);isNaN(a)||(b?h:g).setValue(a)}}}function m(a){if(f){if("boolean"==typeof a){if(z)return;e=a}else a=g.getValue(),z=!0,(e=!e)&&a&&(a*=q/p,isNaN(a)||h.setValue(Math.round(a)));f[e?"removeClass":"addClass"]("cke_btn_unlocked");f.setAttribute("aria-checked",e);CKEDITOR.env.hc&&f.getChild(0).setHtml(e?CKEDITOR.env.ie?"■":"▣":CKEDITOR.env.ie?"□":"▢")}}function u(a){a=a?"enable":"disable";g[a]();h[a]()}var E=/(^\s*(\d+)(px)?\s*$)|^$/i,K=CKEDITOR.tools.getNextId(),L=CKEDITOR.tools.getNextId(),b=k.lang.image2,
c=k.lang.common,P=(new CKEDITOR.template('\x3cdiv\x3e\x3ca href\x3d"javascript:void(0)" tabindex\x3d"-1" title\x3d"'+b.lockRatio+'" class\x3d"cke_btn_locked" id\x3d"{lockButtonId}" role\x3d"checkbox"\x3e\x3cspan class\x3d"cke_icon"\x3e\x3c/span\x3e\x3cspan class\x3d"cke_label"\x3e'+b.lockRatio+'\x3c/span\x3e\x3c/a\x3e\x3ca href\x3d"javascript:void(0)" tabindex\x3d"-1" title\x3d"'+b.resetSize+'" class\x3d"cke_btn_reset" id\x3d"{resetButtonId}" role\x3d"button"\x3e\x3cspan class\x3d"cke_label"\x3e'+
b.resetSize+"\x3c/span\x3e\x3c/a\x3e\x3c/div\x3e")).output({lockButtonId:K,resetButtonId:L}),I=CKEDITOR.plugins.image2,x=k.config,A=k.widgets.registered.image.features,F=I.getNatural,t,y,M,H,p,q,v,w,n,e,z,f,r,g,h,B,C=!(!x.filebrowserImageBrowseUrl&&!x.filebrowserBrowseUrl),N=[{id:"src",type:"text",label:c.url,onKeyup:G,onChange:G,setup:function(a){this.setValue(a.data.src)},commit:function(a){a.setData("src",this.getValue())},validate:CKEDITOR.dialog.validate.notEmpty(b.urlMissing)}];C&&N.push({type:"button",
id:"browse",style:"display:inline-block;margin-top:14px;",align:"center",label:k.lang.common.browseServer,hidden:!0,filebrowser:"info:src"});return{title:b.title,minWidth:250,minHeight:100,onLoad:function(){t=this._.element.getDocument();H=O()},onShow:function(){y=this.widget;M=y.parts.image;n=z=e=!1;B=F(M);v=p=B.width;w=q=B.height},contents:[{id:"info",label:b.infoTab,elements:[{type:"vbox",padding:0,children:[{type:"hbox",widths:["100%"],children:N}]},{id:"alt",type:"text",label:b.alt,setup:function(a){this.setValue(a.data.alt)},
commit:function(a){a.setData("alt",this.getValue())}},{type:"hbox",widths:["25%","25%","50%"],requiredContent:A.dimension.requiredContent,children:[{type:"text",width:"45px",id:"width",label:c.width,validate:D,onKeyUp:J,onLoad:function(){g=this},setup:function(a){this.setValue(a.data.width)},commit:function(a){a.setData("width",this.getValue())}},{type:"text",id:"height",width:"45px",label:c.height,validate:D,onKeyUp:J,onLoad:function(){h=this},setup:function(a){this.setValue(a.data.height)},commit:function(a){a.setData("height",
this.getValue())}},{id:"lock",type:"html",style:"margin-top:18px;width:40px;height:20px;",onLoad:function(){function a(a){a.on("mouseover",function(){this.addClass("cke_btn_over")},a);a.on("mouseout",function(){this.removeClass("cke_btn_over")},a)}var b=this.getDialog();f=t.getById(K);r=t.getById(L);f&&(b.addFocusable(f,4+C),f.on("click",function(a){m();a.data&&a.data.preventDefault()},this.getDialog()),a(f));r&&(b.addFocusable(r,5+C),r.on("click",function(a){n?(g.setValue(v),h.setValue(w)):(g.setValue(p),
h.setValue(q));a.data&&a.data.preventDefault()},this),a(r))},setup:function(a){m(a.data.lock)},commit:function(a){a.setData("lock",e)},html:P}]},{type:"hbox",id:"alignment",requiredContent:A.align.requiredContent,children:[{id:"align",type:"radio",items:[[c.alignNone,"none"],[c.alignLeft,"left"],[c.alignCenter,"center"],[c.alignRight,"right"]],label:c.align,setup:function(a){this.setValue(a.data.align)},commit:function(a){a.setData("align",this.getValue())}}]},{id:"hasCaption",type:"checkbox",label:b.captioned,
requiredContent:A.caption.requiredContent,setup:function(a){this.setValue(a.data.hasCaption)},commit:function(a){a.setData("hasCaption",this.getValue())}}]},{id:"Upload",hidden:!0,filebrowser:"uploadButton",label:b.uploadTab,elements:[{type:"file",id:"upload",label:b.btnUpload,style:"height:40px"},{type:"fileButton",id:"uploadButton",filebrowser:"info:src",label:b.btnUpload,"for":["Upload","upload"]}]}]}});