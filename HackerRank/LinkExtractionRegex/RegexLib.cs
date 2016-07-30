using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkExtractionRegex
{
    public static class RegexLib
    {
        public const string ATagWithHref = "<\\s*a[^<>]*href\\s*=\\s*\"([^\"]*)\"[^<>]*>(?:.(?!(<\\s*a[^<>]*>|<\\s*\\/\\s*a\\s*>)))*.<\\s*\\/\\s*a\\s*>";
        public const string ATag = "<\\s*a[^<>]*>(?:.(?!(<\\s*a[^<>]*>|<\\s*\\/\\s*a\\s*>)))*.<\\s*\\/\\s*a\\s*>";
        public const string Tag = @"<\s*(\S[^<>\s]*)(?:(?:\s*>)|(?:[^<>]*>))(?:.(?!\1))*/\1\s*>";

    }
}
