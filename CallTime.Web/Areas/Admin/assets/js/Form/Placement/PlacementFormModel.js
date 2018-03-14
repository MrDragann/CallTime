var Placement = Placement || {};

/*********************** Placement.PlacementFormModel **********************************************/
(function () {

    if (Placement.PlacementFormModel) {
        console.error('Placement.PlacementFormModel уже был создан');
        return;
    }

    /**
     * Класс для работы с таблицей модели брендов
     */
    Placement.PlacementFormModel = function (theParams) {
        theParams = theParams || {};
        this.UrlDelete = theParams.UrlDelete;

        this.Filter = new Base.BaseFilterModel();
        this.Table = new Components.Table({ Url: theParams.UrlLoadItems, ModalClass: Placement.PlacementModel, Filter: this.Filter });
        this.TableRefresh = this.Table.Refresh.bind(this.Table);

        return this;
    };

    /**
     * Определяем конструктор
     */
    Placement.PlacementFormModel.prototype.constructor = Placement.PlacementFormModel;

    Placement.PlacementFormModel.prototype.DeletePlacement = function (data) {
        var self = this;

        bootbox.confirm("Вы действительно хотите место размещения \"" + data.Name() + "\"?",
            function(e) {
                if (e) {
                    $.post(self.UrlDelete, { placementId: data.Id() })
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