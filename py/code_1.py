symbols = {"0": "⼔",
"1": "◑",
"2": "✦",
"3": "╀",
"4": "⧩",
"5": "й",
"6": "ↂ",
"7": "Ⲃ",
"8": "ⱗ",
"9": "Ⱅ",
"да": "⦴",
"нет": "₷",
"=": "⿎",
"+": "⋊",
"-": "∯",
"*": "➞",
"/": "₠",
">": "ѱ",
"<": "Ӓ",
"?": "Ђ"}


file = open("text.md", "r+", encoding="utf-8")

text = file.read()
file.close()

for key in symbols:
    text = text.replace(key, symbols[key])

with open("result.txt", "w", encoding="utf-8") as new_file:
    new_file.write(text)