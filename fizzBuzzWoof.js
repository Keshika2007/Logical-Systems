function fizzBuzzWoof(n) {
    for (let i = 1; i <= n; i++) {
        let output = '';
        let numStr = i.toString();

        // Check if divisible by 3, 5, or 7
        if (i % 3 === 0) output += 'Fizz ';
        if (i % 5 === 0) output += 'Buzz ';
        if (i % 7 === 0) output += 'Woof ';

        // Check if the number contains 3, 5, or 7
        for (let char of numStr) {
            if (char === '3') output += 'Fizz ';
            if (char === '5') output += 'Buzz ';
            if (char === '7') output += 'Woof ';
        }

        // Trim the trailing space and print the result
        console.log(output.trim() ? `${output.trim()} (${i})` : i);
    }
}

// Example usage
fizzBuzzWoof(35);