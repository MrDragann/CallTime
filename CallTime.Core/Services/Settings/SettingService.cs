using System.Linq;
using CallTime.Core.Enums;
using CallTime.Core.Interfaces;
using CallTime.Core.Models.Responses;
using CallTime.Core.Models.Setting;
using CallTime.Data;

namespace CallTime.Core.Services.Settings
{
    public class SettingService : ISettingService
    {
        /// <summary>
        /// Получить модель настройки
        /// </summary>
        /// <returns></returns>
        public SettingModel GetSettingModel()
        {
            return CurrentSettings.Data;
        }

        /// <summary>
        /// Обновление настроек
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
     //   public BaseResponse UpdateSettings(SettingModel model)
     //   {
     //       using (var db = new DataContext())
     //       {
     //           var ruTitle = db.Settings.FirstOrDefault(x => x.Key == (int)EnumSettingKey.RuTitle);
     //           var enTitle = db.Settings.FirstOrDefault(x => x.Key == (int)EnumSettingKey.EnTitle);
     //           var ruDescription = db.Settings.FirstOrDefault(x => x.Key == (int)EnumSettingKey.RuDescription);
     //           var enDescription = db.Settings.FirstOrDefault(x => x.Key == (int)EnumSettingKey.EnDescription);
     //           var ruKeywords = db.Settings.FirstOrDefault(x => x.Key == (int)EnumSettingKey.RuKeywords);
     //           var enKeywords = db.Settings.FirstOrDefault(x => x.Key == (int)EnumSettingKey.EnKeywords);
     //           var ruAddress = db.Settings.FirstOrDefault(x => x.Key == (int)EnumSettingKey.RuAddress);
     //           var enAddress = db.Settings.FirstOrDefault(x => x.Key == (int)EnumSettingKey.EnAddress);
     //           var phone = db.Settings.FirstOrDefault(x => x.Key == (int)EnumSettingKey.Phone);
     //           var email = db.Settings.FirstOrDefault(x => x.Key == (int)EnumSettingKey.Email);
     //           if (ruTitle == null || enTitle == null || ruDescription == null || enDescription == null ||
     //           ruKeywords == null || enKeywords == null || ruAddress == null || enAddress == null ||
     //                   phone == null || email == null)
					//return new BaseResponse(EnumResponseStatus.Error);

     //           ruTitle.Value = model.RuTitle;
     //           enTitle.Value = model.EnTitle;
     //           ruDescription.Value = model.RuDescription;
     //           enDescription.Value = model.EnDescription;
     //           ruKeywords.Value = model.RuKeywords;
     //           enKeywords.Value = model.EnKeywords;
     //           ruAddress.Value = model.RuAddress;
     //           enAddress.Value = model.EnAddress;
     //           phone.Value = model.Phone;
     //           email.Value = model.Email;

     //           db.SaveChanges();
     //           CurrentSettings.Init();
     //           return new BaseResponse(0, "Настройки успешно изменены");
     //       }
     //   }

    }
}
