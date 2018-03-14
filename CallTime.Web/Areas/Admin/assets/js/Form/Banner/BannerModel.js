var Banner = Banner || {};

(function () {

    if (Banner.BannerModel) {
        console.error("Banner.BannerModel уже был создан");
        return;
    }

    /**
     * Класс для описания модели баннера
     * @param {     
     * } theParams 
     * @returns {} 
     */
    Banner.BannerModel = function (theParams) {
        theParams = theParams || {};

        this.Id = ko.observable(theParams.Id || "");
        this.Title = ko.observable(theParams.Title || "");
        this.Description = ko.observable(theParams.Description || "");
        this.Photo = ko.observable(theParams.Photo || "");

        return this;
    };

    /**
     * Определяем конструктор
     */
    Banner.BannerModel.prototype.constructor = Banner.BannerModel;

    Banner.BannerModel.prototype.log = function (text) {
        console.log("Ошибка в классе Banner.BannerModel: " + text);
    };

    Banner.BannerModel.prototype.GetData = function () {
        return {
            Id: this.Id(),
            Title: this.Title(),
            Description: this.Description(),
            Photo: this.Photo()
        }
    }
})();