using KoiSmart.Models;
using System.Collections.Generic; // Biar kenal List<>

namespace KoiSmart.Interfaces
{
    public interface IIkan
    {
        bool TambahIkan(Ikan ikan);
        bool UpdateIkan(Ikan ikan);
        bool DeleteIkan(int id);

        List<Ikan> AmbilSemuaIkan();

        Ikan GetById(int id);
    }
}