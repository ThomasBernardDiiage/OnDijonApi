using Microsoft.EntityFrameworkCore.Design;

namespace OnDijon.DataAccess;

internal class OnDijonDbContextFactory : IDesignTimeDbContextFactory<OnDijonDbContext>
{
    public OnDijonDbContext CreateDbContext(string[] args)
    {
        const string connection = "Server=tcp:localhost,1433;Initial Catalog=OnDijon;Persist Security Info=False;User ID=sa;Password=Tkm@akpRYh4m?qo4;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;";

        return new OnDijonDbContext(connection);
    }
}

