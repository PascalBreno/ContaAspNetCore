using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Persistence.Configure
{
    public class ContaConfigure : IEntityTypeConfiguration<Conta>
    {
        public void Configure(EntityTypeBuilder<Conta> builder)
        {
            builder.ToTable("Conta");
            builder.HasKey(x => x.ContaId);
            builder.Property(x => x.status);
            builder.Property(x => x.Nome).IsRequired();
            builder.Property(x => x.DataVencimento).IsRequired();
            builder.Property(x => x.ValorOriginal).IsRequired();
            
        }
    }
}