(function () {
  window.dropdowns_fix = {
    dropdownlists: [],
    current_focus: null,
    __window_old_onlick: window.onclick,

    init: function () {
      this.dropdownlists = $('.e-dropdownlist').parent();

      window.onclick = this.winClick;
    },

    winClick: function (e) {
      if (dropdowns_fix.__window_old_onlick)
        dropdowns_fix.__window_old_onlick(e);

      if (dropdowns_fix.current_focus)
        dropdowns_fix.current_focus.css('visibility', 'hidden')
          .css('display', 'none');

      let is_input = dropdowns_fix.dropdownlists.is(e.target);
      let is_caret = dropdowns_fix.dropdownlists.is(e.target.parentElement);

      let dropdown_id = null;
      if (is_input)
        dropdown_id = e.target.firstChild.id + '_popupholder';
      else if (is_caret)
        dropdown_id = e.target.previousElementSibling.id + '_popupholder';

      let prev_focus = dropdowns_fix.current_focus;
      dropdowns_fix.current_focus = dropdowns_fix.focus(dropdown_id);

      if (prev_focus && Object.keys(prev_focus).length > 0) {
        let prev_id = prev_focus.attr('id').replace('_popupholder', '');
        util.delay(50);
        $('#' + prev_id).parent().removeClass('e-icon-anim');
      }
    },

    focus: function (dropdown_id) {
      let dropdown = null;

      if (dropdown_id !== null && !$('#' + dropdown_id).is(this.current_focus)) {
        dropdown = $('#' + dropdown_id).css('visibility', 'visible')
          .css('display', 'contents');

        let dropdown_main = $('#' + dropdown_id.replace('_popupholder', '')).parent();
        if (!dropdown_main.hasClass('e-icon-anim'))
          dropdown_main.addClass('e-icon-anim');
      }

      return dropdown;
    },
  };
})();
