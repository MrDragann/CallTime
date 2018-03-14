var Placement = Placement || {};

(function () {

    if (Placement.PlacementModel) {
        console.error("Placement.PlacementModel уже был создан");
        return;
    }

    /**
     * Класс для описания модели мест размещения
     * @param {     
     * } theParams 
     * @returns {} 
     */
    Placement.PlacementModel = function (theParams) {
        theParams = theParams || {};

        this.Id = ko.observable(theParams.Id || "");
        this.Name = ko.observable(theParams.Name || "");
        this.Photo = ko.observable(theParams.Photo || "");

        return this;
    };

    /**
     * Определяем конструктор
     */
    Placement.PlacementModel.prototype.constructor = Placement.PlacementModel;

    Placement.PlacementModel.prototype.log = function (text) {
        console.log("Ошибка в классе Placement.PlacementModel: " + text);
    };

    Placement.PlacementModel.prototype.GetData = function () {
        return {
            Id: this.Id(),
            Name: this.Name(),
            Photo: this.Photo()
        }
    }
})();