var Banner = Banner || {};

/*********************** Banner.BannerFormModel **********************************************/
(function () {

    if (Banner.BannerFormModel) {
        console.error('Banner.BannerFormModel уже был создан');
        return;
    }

    /**
     * Класс для работы с таблицей модели брендов
     */
    Banner.BannerFormModel = function (theParams) {
        theParams = theParams || {};
        this.UrlDelete = theParams.UrlDelete;

        this.Filter = new Base.BaseFilterModel();
        this.Table = new Components.Table({ Url: theParams.UrlLoadItems, ModalClass: Banner.BannerModel, Filter: this.Filter });
        this.TableRefresh = this.Table.Refresh.bind(this.Table);

        return this;
    };

    /**
     * Определяем конструктор
     */
    Banner.BannerFormModel.prototype.constructor = Banner.BannerFormModel;

    Banner.BannerFormModel.prototype.DeleteBanner = function (data) {
        var self = this;

        bootbox.confirm("Вы действительно хотите удалить баннер \"" + data.Title() + "\"?",
            function(e) {
                if (e) {
                    $.post(self.UrlDelete, { bannerId: data.Id() })
                        .success(function(res) {
                            if (res.IsSuccess) {
                                bootbox.alert(res.Message);
                                self.TableRefresh();
                            }
                            else if (res.Status === Enums.EnumResponseStatus.Exception)
                                console.log("ex:", res.Message);
                            else 
                                bootbox.alert(res.Message);
                        });
                }
            });
    }

})();