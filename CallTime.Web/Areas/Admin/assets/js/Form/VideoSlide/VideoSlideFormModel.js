var VideoSlide = VideoSlide || {};

/*********************** VideoSlide.VideoSlideFormModel **********************************************/
(function () {

    if (VideoSlide.VideoSlideFormModel) {
        console.error('VideoSlide.VideoSlideFormModel уже был создан');
        return;
    }

    /**
     * Класс для работы со справочником видов субконто
     */
    VideoSlide.VideoSlideFormModel = function (theParams) {
        theParams = theParams || {};
        this.UrlSaveChanges = theParams.UrlSaveChanges;
        this.UrlDelete = theParams.UrlDelete;
        this.ModalSelector = theParams.ModalSelector;

        this.Filter = new Base.BaseFilterModel();
        this.Table = new Components.Table({ Url: theParams.UrlLoadItems, ModalClass: VideoSlide.VideoSlideModel, Filter: this.Filter });
        this.TableRefresh = this.Table.Refresh.bind(this.Table);
        
        this.NewVideoSlide = ko.observable(new VideoSlide.VideoSlideModel());

        return this;
    };

    /**
     * Определяем конструктор
     */
    VideoSlide.VideoSlideFormModel.prototype.constructor = VideoSlide.VideoSlideFormModel;

    VideoSlide.VideoSlideFormModel.prototype.ChangeTemplate = function (data) {
        var self = this;
        self.Table.Items().forEach(function (entry, i) {
            entry.IsEdit(false);
        });
        data.IsEdit(true);
    };

    /**
     * Сохраняем изменения
     * @param {} data 
     * @returns {} 
     */
    VideoSlide.VideoSlideFormModel.prototype.SaveChanges = function (data) {
        var self = this;
        var model = data.GetData();
        if (model.IsSuccess) {
            if (self.UrlSaveChanges) {
                $.post(self.UrlSaveChanges, { model: model })
                    .success(function (res) {
                        if (res.IsSuccess) {
                            if (model.Id === "")
                                $(self.ModalSelector).hide();
                            self.TableRefresh();
                        }
                        else {
                            bootbox.alert(res.Message);
                        }
                    })
                    .fail(function (res) {
                        console.log(res);
                    });
            }
        } else {
            bootbox.alert(model.Message);
        }
    };
    /**
     * Сбрасываем шаблон на обычный
     * @param {} data 
     * @returns {} 
     */
    VideoSlide.VideoSlideFormModel.prototype.ResetTemplate = function (data) {
        var self = this;
        self.Table.Items().forEach(function (entry, i) {
            entry.IsEdit(false);
        });
        self.TableRefresh();
    };

    VideoSlide.VideoSlideFormModel.prototype.DeleteVideoSlide = function (data) {
        var self = this;

        if (data) {
            bootbox.confirm("Вы действительно хотите видео слайд?", function (e) {
                if (e) {
                    $.post(self.UrlDelete, {
                            slideId: data.Id()
                        })
                        .done(function (res) {
                            self.TableRefresh();
                            bootbox.alert(res.Message);
                        })
                        .fail(function (res) {
                            bootbox.alert('Неизвестная ошибка при загрузке');
                        });
                }
            });
        }
    }

})();