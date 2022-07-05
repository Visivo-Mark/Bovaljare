(function () {
  window.exterior = {
    images: [],
    mapIndex: {},

    loadImages: async function (data) {
      var self = this, ind = 0,
        imagesLoaded = data.length,
        onLoadImg = function () { imagesLoaded = imagesLoaded - 1; };
      // Load images that use image maps every time
      // TODO: fix so it's not neccessary to load every time;
      //       some bug causes only some image maps to load otherwise
      data.forEach((view, i) => {
        var source, img;

        source = view.sourceImgName;
        img = new Image();
        img.onload = onLoadImg;
        img.id = i + '-img';
        img.src = source;
        $(img).attr({
          view: i,
        });
        self.images.push({
          img: img,
          parentID: '#view-' + i,
          usemap: '#houses-' + i,
          style: { width: '99%' },
        });

        self.mapIndex[view.Name] = ind++;
        /* SUNSTUDY
        imagesLoaded = data.length * 3;
        var name, source, img;
        for (name in view.sunStudies) {
          source = view.sunStudies[name];
          img = new Image();
          img.onload = onLoadImg;
          img.id = 'sun-study-' + i + '-' + name + '-img';
          img.src = source;
          $(img).attr({
            view: i,
            'sun-study': name,
          });
          self.images.push({
            img: img,
            parentID: '#view-' + i + ' #sun-study-' + name,
            usemap: '#houses-' + i + '-' + name,
            style: { width: '99%' },
          });
        }
        /SUNSTUDY */
      });

      /* SUNSTUDY
      var i, name, ind = 0;
      for (i in data) {
        for (name in data[i].sunStudies) {
          this.mapIndex[name + i] = ind++;
        }
      }
      /SUNSTUDY */

      while (imagesLoaded > 0) {
        await util.delay(100);
      }
      return true;
    },

    applyImages: async function () {
      var data;

      for (data of this.images) {
        // Reset any style that may have been added previously,
        // and add in our own
        $(data.img).removeAttr('style');
        $(data.img).css(data.style);
        // Add img element
        $(data.parentID).append(data.img);
        // Add image map functionality
        $('#' + data.img.id).attr('usemap', data.usemap);
        this._loadIM(data.img, data.style.width);
      }
      await util.delay(100);
      // Internally, change image to what is displayed at page start
      this.changeImage(0, 'midday');
    },

    changeImage: function (view) {
      mapster_responsive.changeImage(this.mapIndex[view]);
    },
    /* SUNSTUDY
    changeImage: function (view, sunStudy) {
      mapster_responsive.changeImage(this.mapIndex[sunStudy + view]);
    },
    /SUNSTUDY */

    _loadIM: function (img, imgWidth) {
      var view = $(img).attr('view'),
        imgWidth = imgWidth || $(img).css('width'),
        parentID = 'view-' + view,
        imgID = view + '-img',
        mapName = 'houses-' + view;

      mapster_responsive.setValues(this.mapIndex[view], parentID, imgWidth);
      mapster.addMapHighlights(parentID, imgID, mapName, 'center');
    },
    /* SUNSTUDY
    _loadIM: function (img, imgWidth) {
      var view = $(img).attr('view'),
        sunStudy = $(img).attr('sun-study'),
        imgWidth = imgWidth || $(img).css('width'),
        parentID = 'view-' + view + ' #sun-study-' + sunStudy,
        imgID = 'sun-study-' + view + '-' + sunStudy + '-img',
        mapName = 'houses-' + view + '-' + sunStudy;

      mapster_responsive.setValues(this.mapIndex[sunStudy + view], parentID, imgWidth);
      mapster.addMapHighlights(parentID, imgID, mapName, 'center');
    },
    /SUNSTUDY */

    dispose: function () {
      mapster.dispose();
      this.images.length = 0;
    },
  };
})();
