# Strategy pattern in C# Interfaces

Using a interfaces to make the most out of Unity.

The main idea here is to hijack Unity's methods to prevent them from running non-stop. Now, the interfaces injection allows us to call the magic methods only when we need them. That said, we don't care if Unity calls Update() 60 times a second... we call it once, when needed. Well, that's the idea behind these scripts. This idea was taken from a Unity book called "Learning c# by Developing Games with Unity"


Hack the planet!
