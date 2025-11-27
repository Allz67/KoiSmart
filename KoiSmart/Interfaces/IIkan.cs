using KoiSmart.Models;
using System.Collections.Generic; // Biar kenal List<>

namespace KoiSmart.Interfaces
{
    public interface IIkan
    {
        // CRUD Methods (Harus sama persis nama & tipe datanya sama Controller)

        // Create -> TambahIkan (Return bool)
        bool TambahIkan(Ikan ikan);

        // Update -> UpdateIkan (Return bool)
        bool UpdateIkan(Ikan ikan);

        // Delete -> DeleteIkan (Return bool)
        bool DeleteIkan(int id);

        // Read -> AmbilSemuaIkan (Return List)
        List<Ikan> AmbilSemuaIkan();

        // Read One -> GetById
        Ikan GetById(int id);
    }
}