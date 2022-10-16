using FilmManagement.Core.Entities.Base;
using FilmManagement.Core.Helpers;
using FilmManagement.Core.SharedKernel.Interfaces;

namespace FilmManagement.Core.SharedKernel
{
    public abstract class GuidEntity : BaseEntity, ISoftDelete
    {
        public string Id { get; set; }

        public GuidEntity()
        {
            Id = CommonHelper.NewGuid();
        }
    }
}
