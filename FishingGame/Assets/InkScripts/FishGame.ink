EXTERNAL Name(charName)
EXTERNAL Icon(charName)

VAR FishCaught = 0
VAR FishValue = 0

{Name("Moon")}
{Icon("MoonGoddess")}
Scipt Draft
anthropomorphized moon shows up, surprises protag and friend/antag while fishing

hey i lost my fish can you find it? {FishCaught}

{Name("Rabbit")}
{Icon("Rabbit")}
* Yes
-> Yes
* No
-> No

=== Yes ===
{Name("Moon")}
{Icon("MoonGoddess")}
cool heres some moon powers so you can fish

{Name("Rabbit")}
{Icon("Rabbit")}
wow thanks 
-> DONE

=== No ===
{Name("Moon")}
{Icon("MoonGoddess")}
Why
-> DONE