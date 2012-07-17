include $(top_srcdir)/build.rules.mk

ASSEMBLY=GNOME-Keyring

FILES = \
	src/KeyringItemSource.cs

DLL_CONFIG_FILES = \
	GNOME-Keyring.dll.config

RESOURCES = \
	Resources/GNOME-Keyring.addin.xml

BUILD_DEFINES=$(DBUS_BUILD_DEFINES)

REFERENCES = \
        $(GNOME_KEYRING_SHARP) \
        System \
        System.Core \
        $(GTK_SHARP_20_LIBS) \
        $(DO_PLATFORM_LIBS) \
        $(DO_UNIVERSE_LIBS)
