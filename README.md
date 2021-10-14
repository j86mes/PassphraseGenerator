# PassphraseGenerator
.NET Standard library to generate passphrases from the [EFF.org wordlists](https://www.eff.org/deeplinks/2016/07/new-wordlists-random-passphrases) using the Diceware method.

There are three wordlists included by default, or you can choose to [implement your own wordlist provider](https://github.com/j86mes/PassphraseGenerator/blob/main/README.md#providing-your-own-wordlist).



## Wordlist variations
- **EFF long wordlist (default)** 
  - Uses five dice rolls per word
  - creates memorable strong passphrases, recommended to use at least 6 words per passphrase

- **EFF short wordlist** 
  - Uses four dice rolls per word (smaller set of words)
  - only short words

- **EFF memorable wordlist** 
  - Uses four dice rolls per word (smaller set of words)
  - longer words that may be more memorable

[Further Information about the EFF.org wordlist](https://www.eff.org/deeplinks/2016/07/new-wordlists-random-passphrases)


## Selecting a wordlist

To select a wordlist, simply provide one of the IWordListProvider classes to the PassphraseGenerator, or use the default large word list:
```
var largeWordListPassphraseGenerator = new PassphraseGenerator();
string passphrase = largeWordListPassphraseGenerator.CreatePassphrase(6, " ");

var shortWordListPassphraseGenerator = new PassphraseGenerator(new ShortWordListProvider());
string passphrase = shortWordListPassphraseGenerator.CreatePassphrase(6, " ");

var shortMemorableWordListPassphraseGenerator = new PassphraseGenerator(new MemorableWordListProvider());
string passphrase = shortMemorableWordListPassphraseGenerator.CreatePassphrase(6, " ");

```

## Providing your own wordlist
You can provide any wordlist source, simply implement the IWordListProvider interface, and pass your class to the PassphraseGenerator:

```
class MyCustomListProvider: IWordListProvider{ 
    ... 
}
```

```
var passphraseGenerator = new PassphraseGenerator(new MyCustomListProvider());
string passphrase = passphraseGenerator.CreatePassphrase(6, "-");
```
