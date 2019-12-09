This is something my dad and I worked on together -- a virtual loom. My dad is into woodworking and other crafts, and he made is own loom years ago -- a big contraption as I remember. A long time ago he wrote a program in BASIC to model what a loom does, when given various inputs about the color and configuration of yarn to produce a desired fabric pattern. We were trying to re-create this, as his original program is long gone. He had tried playing around with [SmallBasic](https://smallbasic-publicwebsite.azurewebsites.net), but didn't get very far. I wanted to do it in C# of course as a WinForms app, since that's what I know.

![img](https://github.com/adamosoftware/Loomer/blob/master/herringbone.png)

A big challenge here is that I don't understand looms. My dad understands them deeply, but mainly in a *mechanical* way, not *algorithmically.* He kept using weaving jargon like harness and heddle, warp and weft, and I got particularly tripped up on concepts like "raising" and "lowering" harnesses, coupled with excited hand gestures of interlocked fingers. I maybe could've tried to learn about looms and weaving to get a hands-on feel for it, but we had only few hours. My dad does have a deep background in SQL and database design in fact, but finding a workable common language on the programmatic or algorithmic behavior of looms was pretty elusive at first. In fact, we'd made an attempt at this very app a year ago in this [repo](https://github.com/adamosoftware/Loom). This didn't work out because I never did understand how a loom works, and I ended up approaching weaving as a [repeating stamp pattern](https://github.com/adamosoftware/Loom/blob/master/Loom/Stamp.cs). But this didn't work as a *weaving model*, which is what my dad was after.

By sheer rapid repetitive effort however, starting from "hello world" outputs, we were able to converge on a workable language. In a few hours we got to the point where he would say something like *that's almost right but it needs X* and I would say *oh okay hang on a sec.... I've pushed some changes now try it*. That is quite satisfying when it works!

The heart of the app is the [SimpleWeaver](https://github.com/adamosoftware/Loomer/blob/master/Loomer/SimpleWeaver.cs) class. Here are few highlights:
- There are a few [public properties](https://github.com/adamosoftware/Loomer/blob/master/Loomer/SimpleWeaver.cs#L16..L23) that set colors and other drawing parameters. [HarnessOrder](https://github.com/adamosoftware/Loomer/blob/master/Loomer/SimpleWeaver.cs#L22) is an interesting property that lets you describe a *pattern of patterns.* This was pretty elusive for a while, but the other properties are more obvious I think. I'll talk about Harnesses below.
- The [Draw](https://github.com/adamosoftware/Loomer/blob/master/Loomer/SimpleWeaver.cs#L27) method is where the real work happens. This is what loops over the X and Y coordinates of the drawing space and drawing the correct color square in the right place.
- A [Harness](https://github.com/adamosoftware/Loomer/blob/master/Loomer/SimpleWeaver.cs#L164), something I struggled hard to understand early on, is what describes a pattern of two colors. ("Warp" and "weft" are the two colors.) Early on, I understood the idea of a [simple pattern](https://github.com/adamosoftware/Loomer/blob/master/Loomer/SimpleWeaver.cs#L220), meaning a color that repeats every X squares up to the fabric width. More critically, we had to implement the idea of a [complex pattern](https://github.com/adamosoftware/Loomer/blob/master/Loomer/SimpleWeaver.cs#L187). This is what the screenshot above shows in use, a string of plus/minus symbols and numbers. This is how we expressed a repeating pattern of arbitrary lengths of on-off segments. So, **+2-3+1-3** means "2 squares on, 3 squares off, 1 square on, 3 squares off."
- [Harness groups](https://github.com/adamosoftware/Loomer/blob/master/Loomer/SimpleWeaver.cs#L90) were a difficult concept for me grasp, but it lets you combine and arrange harnesses. Each harness is identified by a letter, for example A, B, and C. You set the [HarnessOrder](https://github.com/adamosoftware/Loomer/blob/master/Loomer/SimpleWeaver.cs#L22) to a string like "AA BB CC" to repeat each harness twice, for example, or use something like "A B B A " to weave them in ascending followed by descending order to produce diagonal patterns that go up then down, for example.
