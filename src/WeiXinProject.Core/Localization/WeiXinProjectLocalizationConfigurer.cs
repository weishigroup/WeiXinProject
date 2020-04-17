using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace WeiXinProject.Localization
{
    public static class WeiXinProjectLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(WeiXinProjectConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(WeiXinProjectLocalizationConfigurer).GetAssembly(),
                        "WeiXinProject.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
