using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace pkhmelyov.AbpReposterBot.Localization
{
    public static class AbpReposterBotLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(AbpReposterBotConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(AbpReposterBotLocalizationConfigurer).GetAssembly(),
                        "pkhmelyov.AbpReposterBot.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
