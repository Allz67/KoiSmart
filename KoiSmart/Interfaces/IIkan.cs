using KoiSmart.Models;

namespace KoiSmart.Interfaces
{
    public interface IIkan
    {
        void CreateIkan(Ikan ikan);
        void UpdateIkan(Ikan ikan);
        void DeleteIkan(int id);
        Ikan GetById(int id);
        List<Ikan> GetAllIkan();
    }
}