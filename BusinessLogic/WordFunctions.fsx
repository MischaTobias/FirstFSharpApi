let makeLowerCase (s:string) = 
  s.ToLower() 

let toLowerIfStartsWithVowel (word: string) =
    let isVowel (c: char) =
        match c with
        | 'a' | 'e' | 'i' |'o' |'u'
        | 'A' | 'E' | 'I' | 'O' | 'U' -> true
        |_ -> false
    
    if isVowel word[0] then
        makeLowerCase(word)
    else
        word