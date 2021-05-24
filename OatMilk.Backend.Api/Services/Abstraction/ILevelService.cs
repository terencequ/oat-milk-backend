using System.Collections.Generic;
using System.Threading.Tasks;
using OatMilk.Backend.Api.Services.Models.Requests;
using OatMilk.Backend.Api.Services.Models.Responses;
using OatMilk.Backend.Api.Services.Pagination;

namespace OatMilk.Backend.Api.Services.Abstraction
{
    public interface ILevelService : IUserEntityService<LevelRequest, LevelResponse>
    {
        /// <summary>
        /// This will populate the user's character level definitions with new base data.
        /// Any custom levels will be deleted by this process.
        /// </summary>
        /// <returns>Collection of levels.</returns>
        Task<PageResponse<LevelResponse>> ResetLevels();
    }
}