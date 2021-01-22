using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace caner.Models
{
    public class Sube
    {
        public virtual int Id { get; set; }
        public virtual string Ad { get; set; }
        public virtual string Telefon { get; set; }
        public virtual Otel Oteladi { get; set; }

    }

    public class SubeMap : ClassMapping<Sube>
    {
        public SubeMap()
        {
            Table("Sube");
            Id(x => x.Id, m => m.Generator(Generators.Native));
            Property(x => x.Ad, c => c.Length(40));
            Property(x => x.Telefon, c => c.Length(20));
            ManyToOne(x => x.Oteladi);
        }
    }
}