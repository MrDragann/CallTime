var Application = Application || {};

(function () {

    if (Application.ApplicationModel) {
        console.error("Application.ApplicationModel уже был создан");
        return;
    }

    /**
     * Класс для описания модели баннера
     * @param {     
     * } theParams 
     * @returns {} 
     */
    Application.ApplicationModel = function (theParams) {
        theParams = theParams || {};

        this.Id = ko.observable(theParams.Id || "");
        this.Name = ko.observable(theParams.Name || "");
        this.Email = ko.observable(theParams.Email || "");
        this.Message = ko.observable(theParams.Message || "");
        this.DateCreate = ko.observable(theParams.DateCreate || "");
        this.IsNew = ko.observable(theParams.IsNew || "");

        return this;
    };

    /**
     * Определяем конструктор
     */
    Application.ApplicationModel.prototype.constructor = Application.ApplicationModel;

    Application.ApplicationModel.prototype.log = function (text) {
        console.log("Ошибка в классе Application.ApplicationModel: " + text);
    };

    Application.ApplicationModel.prototype.GetData = function () {
        return {
            Id: this.Id(),
            Title: this.Title(),
            Description: this.Description(),
            Photo: this.Photo()
        }
    }
})();