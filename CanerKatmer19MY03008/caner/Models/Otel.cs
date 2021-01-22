using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;

namespace caner.Models
{
    [Serializable]
    public class Otel
    {
        public virtual int Id { get; set; }
        public virtual string Ad { get; set; }
        public virtual string Sehir { get; set; }
        public virtual string Telefon { get; set; }
        public virtual ICollection<Sube> Subeler { get; set; } = new List<Sube>();
    }

    public class OtelMap : ClassMapping<Otel>
    {
        public OtelMap()
        {
            Table("Otel");
            Id(x => x.Id, m => m.Generator(Generators.Native));
            Property(x => x.Ad, c => c.Length(20));
            Property(x => x.Telefon, c => c.Length(20));
            Property(x => x.Sehir, c => c.Length(30));

            Set(e => e.Subeler,
                mapper =>
                {
                    mapper.Key(k => k.Column("OtelAdi"));
                    mapper.Inverse(true);
                    mapper.Cascade(Cascade.All);
                },
               relation => relation.OneToMany(mapping => mapping.Class(typeof(Otel))));
        }
    }
}