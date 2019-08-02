# InjectionUsingInterfaces
Using Interfaces to cut Unity's magic methods


The idea here is to hijack Unity's methods to prevent then from running all the time. Now, the interfaces injection allow us to call the magic methods only when we want. That said, we don't care if Unity calls Update() 60 times a second... we call it once, when we want. Well, that's the idea behind these scripts. This idea was taken from a Unity book on "supposedly" "good" "practices".

Hack the planet!
