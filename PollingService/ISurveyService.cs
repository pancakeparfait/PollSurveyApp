using System.Collections.Generic;
using PollingModel;

namespace PollingService
{
    public interface ISurveyService
    {
        bool CreateSurvey(SurveyCreate model);
        IEnumerable<SurveyModel> GetSurveys();
        SurveyDetail GetSurveyById(int userId);
        bool UpdateSurvey(SurveyEdit model);
        bool DeleteSurvey(int userId);
    }
}