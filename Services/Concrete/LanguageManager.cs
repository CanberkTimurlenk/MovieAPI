using AutoMapper;
using Models.Concrete.Entities;
using Models.Concrete.RequestModels.Insertion.Language;
using Models.Concrete.RequestModels.Update.Actor;
using Models.Concrete.RequestModels.Update.Langauge;
using Repositories.Abstract;
using Services.Abstract;

namespace Services.Concrete
{
    public class LanguageManager : ILanguageService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public LanguageManager(IRepositoryManager repositoryManager, IMapper mapper) 
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<int> CreateAsync(LanguageRequestForInsertion language)
        {
            var languageToCreate = _mapper.Map<Language>(language);

            await _repositoryManager.Language.CreateAsync(languageToCreate);
            await _repositoryManager.SaveAsync();

            return languageToCreate.Id;

        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            var language = await _repositoryManager.Language.FindAsync(id);

            var result = _repositoryManager.Language.Remove(language);

            await _repositoryManager.SaveAsync();

            return result;

        }

        public async Task<Language> FindByIdAsync(int id)

          => await _repositoryManager.Language.FindAsync(id);

        public async Task<(LanguageRequestForUpdate languageRequestForUpdate, Language language)> GetLanguageForPatchAsync(int id)
        {
            var languageToUpdate = await _repositoryManager.Language.FindAsync(id);

            var languageRequestForUpdate = _mapper.Map<LanguageRequestForUpdate>(languageToUpdate);

            return (languageRequestForUpdate, languageToUpdate);

        }

        public async Task SaveChangesForPatchAsync(LanguageRequestForUpdate languageRequest, Language language)
        {
            _mapper.Map(languageRequest, language);
            await _repositoryManager.SaveAsync();
        }

        public async Task UpdateAsync(int languageId, LanguageRequestForUpdate LanguageRequestForUpdate)
        {
            var language = await _repositoryManager.Language.FindAsync(languageId);

            if (language is null)
                throw new Exception();

            language = _mapper.Map<Language>(LanguageRequestForUpdate);

            _repositoryManager.Language.Update(language);
            await _repositoryManager.SaveAsync();
        }
    }
}
