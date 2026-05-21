namespace editgrif;

internal static class ConfigValues
{
    internal const string configValuesResource = "editgrif.configvalues.grif";

    internal const string DEFAULT_PREFIX_ROOM = "room";
    internal const string DEFAULT_PREFIX_ITEM = "item";
    internal const string DEFAULT_PREFIX_MESSAGE = "message,modmsg";
    internal const string DEFAULT_PREFIX_VALUE = "value";
    internal const string DEFAULT_PREFIX_VOCABULARY = "verb,noun,adjective,preposition,article";
    internal const string DEFAULT_PREFIX_COMMAND = "command";
    internal const string DEFAULT_PREFIX_SCRIPT = "script,background";
    internal const string DEFAULT_PREFIX_SYSTEM = "system";
    internal const string DEFAULT_PREFIX_DIRECTION = "direction";

    internal const string SYSTEM_PREFIX_ROOM_KEY = "system.prefix.room";
    internal const string SYSTEM_PATTERN_ROOM_SHORTDESC_KEY = "system.pattern.room.shortdesc";
    internal const string SYSTEM_PATTERN_ROOM_LONGDESC_KEY = "system.pattern.room.longdesc";
    internal const string SYSTEM_PATTERN_ROOM_EXIT_KEY = "system.pattern.room.exit";
    internal const string SYSTEM_PREFIX_ITEM_KEY = "system.prefix.item";
    internal const string SYSTEM_PATTERN_ITEM_SHORTDESC_KEY = "system.pattern.item.shortdesc";
    internal const string SYSTEM_PATTERN_ITEM_LONGDESC_KEY = "system.pattern.item.longdesc";
    internal const string SYSTEM_PATTERN_ITEM_LOCATION_KEY = "system.pattern.item.location";
    internal const string SYSTEM_PREFIX_MESSAGE_KEY = "system.prefix.message";
    internal const string SYSTEM_PREFIX_VALUE_KEY = "system.prefix.value";
    internal const string SYSTEM_PREFIX_VOCABULARY_KEY = "system.prefix.vocabulary";
    internal const string SYSTEM_PREFIX_COMMAND_KEY = "system.prefix.command";
    internal const string SYSTEM_PREFIX_SCRIPT_KEY = "system.prefix.script";
    internal const string SYSTEM_PREFIX_SYSTEM_KEY = "system.prefix.system";
    internal const string SYSTEM_PREFIX_DIRECTION_KEY = "system.prefix.direction";

    internal const string DEFAULT_PATTERN_ROOM_SHORTDESC = "{roomprefix}.{room}.shortdesc";
    internal const string DEFAULT_PATTERN_ROOM_LONGDESC = "{roomprefix}.{room}.longdesc";
    internal const string DEFAULT_PATTERN_ROOM_EXIT = "{roomprefix}.{room}.exit.{direction}";

    internal const string DEFAULT_PATTERN_ITEM_SHORTDESC = "{itemprefix}.{item}.shortdesc";
    internal const string DEFAULT_PATTERN_ITEM_LONGDESC = "{itemprefix}.{item}.longdesc";
    internal const string DEFAULT_PATTERN_ITEM_LOCATION = "{itemprefix}.{item}.location";

    internal const string SYSTEM_GAMENAME = "system.gamename";
    internal const string SYSTEM_GAMETITLE = "system.gametitle";
    internal const string SYSTEM_VERSION = "system.version";
    internal const string SYSTEM_INTRO = "system.intro";

    internal const string DEFAULT_PLAYER_LOCATION_KEY = "value.room";
    internal const string SYSTEM_PLAYER_LOCATION = "system.player.location";

    internal const string OVERLAY_EXTENSION = ".overlay";
}
