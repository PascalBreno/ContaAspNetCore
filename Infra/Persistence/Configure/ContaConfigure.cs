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
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Status);
            builder.Property(x => x.Nome).IsRequired();
            builder.Property(x => x.DataVencimento).IsRequired();
            builder.Property(x => x.DataPagamento).IsRequired();
            builder.Property(x => x.ValorOriginal).IsRequired();
            builder.Property(x => x.DiasDeAtraso).IsRequired().HasDefaultValue(0);
            builder.Property(x => x.IsDeleted).HasDefaultValue(false);
            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}