var Application = Application || {};

/*********************** Application.ApplicationFormModel **********************************************/
(function () {

    if (Application.ApplicationFormModel) {
        console.error('Application.ApplicationFormModel уже был создан');
        return;
    }

    /**
     * Класс для работы с таблицей модели брендов
     */
    Application.ApplicationFormModel = function (theParams) {
        theParams = theParams || {};
        this.UrlDelete = theParams.UrlDelete;

        this.Filter = new Base.BaseFilterModel();
        this.Table = new Components.Table({ Url: theParams.UrlLoadItems, ModalClass: Application.ApplicationModel, Filter: this.Filter });
        this.TableRefresh = this.Table.Refresh.bind(this.Table);

        return this;
    };

    /**
     * Определяем конструктор
     */
    Application.ApplicationFormModel.prototype.constructor = Application.ApplicationFormModel;

    Application.ApplicationFormModel.prototype.DeleteApplication = function (data) {
        var self = this;

        bootbox.confirm("Вы действительно хотите удалить заявку?",
            function(e) {
                if (e) {
                    $.post(self.UrlDelete, { applicationId: data.Id() })
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