using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace BuilderDemo
{
    public class ResourcePoolConfig
    {
        private String name;
        private Int32 maxTotal;
        private Int32 maxIdle;
        private Int32 minIdle;
        private ResourcePoolConfig(Builder builder)
        {
            this.name = builder.name;
            this.maxTotal = builder.maxTotal;
            this.maxIdle = builder.maxIdle;
            this.minIdle = builder.minIdle;
        }

        public String GetName()
        {
            return this.name;
        }

        public class Builder
        {
            private static Int32 DEFAULT_MAX_TOTAL = 8;
            private static Int32 DEFAULT_MAX_IDLE = 8;
            private static Int32 DEFAULT_MIN_IDLE = 0;

            public String name { get; private set; }
            public Int32 maxTotal { get; private set; }
            public Int32 maxIdle { get; private set; }
            public Int32 minIdle { get; private set; }
            public Builder()
            {
                this.maxTotal = DEFAULT_MAX_TOTAL;
                this.maxIdle = DEFAULT_MAX_IDLE;
                this.minIdle = DEFAULT_MIN_IDLE;
            }

            public ResourcePoolConfig build()
            {
                if (String.IsNullOrEmpty(name))
                {
                    throw new ArgumentNullException("name");
                }
                if (maxIdle > maxTotal)
                {
                    throw new ArgumentOutOfRangeException("maxIdle");
                }
                if (minIdle > maxTotal || minIdle > maxIdle)
                {
                    throw new ArgumentOutOfRangeException("minIdle");
                }
                return new ResourcePoolConfig(this);
            }

            public Builder setName(String name)
            {
                if (String.IsNullOrEmpty(name))
                {
                    throw new ArgumentNullException();
                }
                this.name = name;
                return this;
            }

            public Builder setMaxTotal(Int32 maxTotal)
            {
                if (maxTotal <= 0)
                {
                    throw new ArgumentException("maxTotal");
                }
                this.maxTotal = maxTotal;
                return this;
            }

            public Builder setMaxIdle(Int32 maxIdle)
            {
                if (maxIdle < 0)
                {
                    throw new ArgumentException("maxIdle");
                }
                this.maxIdle = maxIdle;
                return this;
            }

            public Builder setMinIdle(Int32 minIdle)
            {
                if (minIdle < 0)
                {
                    throw new ArgumentException("minIdle");
                }
                this.minIdle = minIdle;
                return this;
            }
        }
    }
}
