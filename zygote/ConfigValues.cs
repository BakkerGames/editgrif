namespace zygote;

internal static class ConfigValues
{
    internal const string DEFAULT_PREFIX_COMMAND = "command";
    internal const string DEFAULT_PREFIX_ITEM = "item";
    internal const string DEFAULT_PREFIX_MESSAGE = "message";
    internal const string DEFAULT_PREFIX_ROOM = "room";
    internal const string DEFAULT_PREFIX_SCRIPT = "script,background";
    internal const string DEFAULT_PREFIX_SYSTEM = "system";
    internal const string DEFAULT_PREFIX_VALUE = "value";
    internal const string DEFAULT_PREFIX_VOCABULARY = "verb,noun,adjective,preposition,article";

    internal const string SYSTEM_PREFIX_COMMAND_KEY = "system.prefix.command";
    internal const string SYSTEM_PREFIX_ITEM_KEY = "system.prefix.item";
    internal const string SYSTEM_PREFIX_MESSAGE_KEY = "system.prefix.message";
    internal const string SYSTEM_PREFIX_ROOM_KEY = "system.prefix.room";
    internal const string SYSTEM_PREFIX_SCRIPT_KEY = "system.prefix.script";
    internal const string SYSTEM_PREFIX_SYSTEM_KEY = "system.prefix.system";
    internal const string SYSTEM_PREFIX_VALUE_KEY = "system.prefix.value";
    internal const string SYSTEM_PREFIX_VOCABULARY_KEY = "system.prefix.vocabulary";

    internal const string DEFAULT_PATTERN_ROOM_SHORTDESC = "room.{room}.shortdesc";
    internal const string DEFAULT_PATTERN_ROOM_LONGDESC = "room.{room}.longdesc";
    internal const string DEFAULT_PATTERN_ROOM_EXIT = "room.{room}.exit.{exit}";

    internal const string DEFAULT_PATTERN_ITEM_SHORTDESC = "item.{item}.shortdesc";
    internal const string DEFAULT_PATTERN_ITEM_LONGDESC = "item.{item}.longdesc";
    internal const string DEFAULT_PATTERN_ITEM_LOCATION = "item.{item}.location";
}
