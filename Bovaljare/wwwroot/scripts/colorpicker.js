﻿(function () {
  window.colorpicker = {
    images: {},
    imageMaps: [],
    listeners: {},
    imageType: {
      image: 0,
      panorama: 1,
      vr: 2,
      roundme: 3,
    },


    hideColorpicker: function () {
      if ($(houseinputid).val() == 99) {
        $(colorpick).removeClass("colorpickermenu")
        $(colorpick).addClass("colorpickermenu2")
        $(colorpickslink).addClass("animate__animated animate__bounce")
      }
    },

    //adjustfloorplan: function () {
    //    var width2 = parseInt($('#floorplan-0-img').width());
    //    var newheight = width2 * 0.75
    //    $('#floorplan-0-img').height(newheight)
    //    $('.mapster_el').height(newheight)
    //},

    adjustPan: function () {
      var width = parseInt($('#carousel-item-0').width());
      width = width * 0.75
      $('.iframe-container iframe').height(width + 'px');
    },

    addResizeListener: function () {
      var self = this;

      this.listeners.resize = function (e) { self._onResize(e); };
      window.addEventListener('resize', this.listeners.resize, false);
    },

    loadImages: async function (houseType, data) {
      var self = this,
        imagesLoaded = data.floorplans.length,
        onLoadImg = function () { imagesLoaded = imagesLoaded - 1; };
      // Load images that use image maps every time
      // TODO: fix so it's not neccessary to load every time;
      //       some bug causes only some image maps to load otherwise
      data.floorplans.forEach((floorplan, i) => {
        var img = new Image();
        img.onload = onLoadImg;
        img.id = 'floorplan-' + i + '-img';
        img.src = floorplan.source;
        $(img).attr('floor', i);
        self.imageMaps.push({
          img: img,
          parentID: 'floorplan-' + i,
          usemap: '#hotspots-' + i,
          style: { width: '99.99%' },
        });
      });

      if (this.images[houseType]) {
        return true;
      }

      var imageData = [];
      imagesLoaded = imagesLoaded + data.images.length;

      var ind = 0;
      data.images.forEach((image, i) => {
        var img = $("#galler" + i), _ind = ind;


        //var img = new Image(), _ind = ind;
        //img.src = image.source;
        //$(img).addClass('gallery-img');
        //$(img).on('click', e => self._onClickGalleryImg(e, i));


        img.onload = onLoadImg;
        if (image.type === this.imageType.image || image.type === this.imageType.roundme) {
          $(img).attr('c_ind', _ind);
          ind = ind + 1;
        }
        imageData.push({
          img: img,
          parentID: 'gallery-item-' + i,
        });

        var carouselImg = $("#carosal" + i);
        imageData.push({
          img: carouselImg,
          parentID: 'carousel-item-' + i,
        });

        //if (image.type === this.imageType.image) {
        //    var carouselImg = img.cloneNode();
        //    $(carouselImg).removeClass();
        //    $(carouselImg).addClass('d-block w-100');
        //    $(carouselImg).on('click', e => self._onClickCarousel(e));
        //    imageData.push({
        //        img: carouselImg,
        //        parentID: 'carousel-item-' + i,
        //    });
        //}

        //if (image.type === this.imageType.roundme) {
        //    var carouselImg = img.cloneNode();
        //    $(carouselImg).removeClass();
        //    $(carouselImg).addClass('hideit');
        //    $(carouselImg).on('click', e => self._onClickCarousel(e));
        //    imageData.push({
        //        img: carouselImg,
        //        parentID: 'carousel-item-' + i,
        //    });
        //}

      });

      this.images[houseType] = imageData;
      //while (imagesLoaded > 0) {
      // await util.delay(100);
      //}
      return true;
    },

    applyImages: function (houseType) {
      var data;

      //for (data of this.images[houseType]) {
      //    // Remove any style that may have been added previously
      //    $(data.img).removeAttr('style');
      //    // Add img element
      //    $('#' + data.parentID).append(data.img);
      //}

      for (data of this.imageMaps) {
        // Reset any style that may have been added previously,
        // and add in our own
        $(data.img).removeAttr('style');
        if (data.style)
          $(data.img).css(data.style);
        // Add img element
        $('#' + data.parentID).append(data.img);
        // Add image map functionality
        $('#' + data.img.id).attr('usemap', data.usemap);
        this._loadFloorplan(data.img, data.style.width);

      }
    },

    dispose: function () {
      this.imageMaps.length = 0;
      window.removeEventListener('resize', this.listeners.resize, false);
    },

    resize: function () {
      this._onResize();
    },

    changeRoom: function (oldImage, newImage) {



      if (oldImage.type === this.imageType.panorama &&
        newImage.type !== this.imageType.panorama) {
        var img = util.getImgElement(newImage.source, '#gallery');
        bstrap.carousel_changeImage(parseInt($(img).attr('c_ind')));
      }

      if (newImage.type === this.imageType.image) {
        var img = util.getImgElement(newImage.source, '#gallery');
        bstrap.carousel_changeImage(parseInt($(img).attr('c_ind')));
      }

      else {
        var img = util.getImgElement(newImage.source, '#gallery');
        bstrap.carousel_changeImage(parseInt($(img).attr('c_ind')));
      }
    },

    _loadFloorplan: async function (img, imgWidth) {
      var floor = $(img).attr('floor'),
        imgWidth = imgWidth || $(img).css('width'),
        parentID = 'floorplan-' + floor;

      mapster_responsive.setValues(parseInt(floor), parentID, imgWidth);
      mapster.addMapHighlights(parentID, parentID + '-img', 'hotspots-' + floor, '', 0.6, 0.9);

      var height1 = parseInt($('.planritning').height());
      var height2 = parseInt($('#gallery').height());
      var height3 = parseInt($('#info').height());

      var height4 = height3 + height2 + height1 + 60;

      $('.iframe-container iframe').height(height4 + 'px');

      mapster.selectAll();
    },

    _onClickCarousel: function (event) {
      var self = this;
      $('.fs-border img').remove();
      var img = $(event.target).clone();
      img.removeClass();
      img.css({ width: '100%' });
      img.appendTo('.fs-border');
      DotNet.invokeMethodAsync('Bovaljare', 'ShowImage')
        .then(_data => { self._onResize(); });

    },

    _onClickGalleryImg: function (event, ind) {
      var self = this;
      DotNet.invokeMethodAsync('Bovaljare', 'ChangeRoom', ind)
        .then(r => {
          self.changeRoom(r[0], r[1]);
        });
    },

    _onResize: function (event) {

      if ($(window).width() <= 927) {
        var height = parseInt($('.planritning').height());
        $('#gallery').height((height + 3) + 'px');
        $('#info').height('auto')


      }
      else if ($(window).width() <= 1380) {
        var height1 = parseInt($('.planritning').height());
        var height2 = parseInt($('#gallery').height());
        var height3 = parseInt($('#slideshow').height());

        var height4 = height3 - height2 - height1 - 35;


        $('#info').height(height4 + 'px');
        var width1 = parseInt($('#carousel-item-0').width());
        width1 = width1 * 0.75
        $('.iframe-container iframe').height(width1 + 'px');

      }

      else {

        var width1 = parseInt($('#carousel-item-0').width());
        width1 = width1 * 0.75
        $('.iframe-container iframe').height(width1 + 'px');

        var height1 = parseInt($('.planritning').height());
        var height2 = parseInt($('#gallery').height());
        var height3 = parseInt($('#slideshow').height());
        var height4 = height3 - height2 - height1 - 57;
        $('#gallery').height('auto');
        $('#info').height(height4 + 'px');

      }

      var height = Math.max($('.fs-border').height() + 97, $(window).height());
      $('.fs-bg').height(height);
    },
  };
})();
