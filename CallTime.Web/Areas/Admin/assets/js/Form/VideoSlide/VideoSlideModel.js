var VideoSlide = VideoSlide || {};

(function () {

    if (VideoSlide.VideoSlideModel) {
        console.error("VideoSlide.VideoSlideModel уже был создан");
        return;
    }

    /**
     * Класс для описания модели города
     * @param {     
     * } theParams 
     * @returns {} 
     */
    VideoSlide.VideoSlideModel = function (theParams) {
        theParams = theParams || {};

        this.Id = ko.observable(theParams.Id || ""); 
        this.Url = ko.observable(theParams.Url || "");
        this.PreviewUrl = ko.observable(theParams.PreviewUrl || "");

        this.IsEdit = ko.observable(theParams.IsEdit || false);
        return this;
    };

    /**
     * Определяем конструктор
     */
    VideoSlide.VideoSlideModel.prototype.constructor = VideoSlide.VideoSlideModel;

    VideoSlide.VideoSlideModel.prototype.log = function (text) {
        console.log("Ошибка в классе VideoSlide.VideoSlideModel: " + text);
    };

    VideoSlide.VideoSlideModel.prototype.GetData = function () {
        var model = {
            Id: this.Id(),
            Url: this.Url(),
            IsSuccess: false
        }
        if (model.Url === "") {
            model.Message = "Ссылка не может быть пустой";
        } else
            model.IsSuccess = true;
        return model;
    }
})();