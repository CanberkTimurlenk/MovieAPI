using AutoMapper;
using Models.Concrete.Entities;
using Models.Concrete.RequestModels.Insertion.Language;
using Models.Concrete.RequestModels.Update.Langauge;
using Repositories.Abstract;
using Repositories.Concrete.EFCore;

namespace Services.Abstract
{
    public interface ILanguageService
    {

        Task<int> CreateAsync(LanguageRequestForInsertion languageRequestForInsertion);
        Task<bool> DeleteByIdAsync(int id);
        Task<Language> FindByIdAsync(int id);
        Task<(LanguageRequestForUpdate languageRequestForUpdate, Language language)> GetLanguageForPatchAsync(int id);
        Task SaveChangesForPatchAsync(LanguageRequestForUpdate languageRequestForUpdate, Language language);
        Task UpdateAsync(int languageId, LanguageRequestForUpdate languageRequestForUpdate);
    }
}