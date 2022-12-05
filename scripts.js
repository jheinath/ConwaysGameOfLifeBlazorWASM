function toggleDarkMode() {
    const elements = document.querySelectorAll("[class*=bg-light]");
    if (elements.length > 0){
        const elementsDark = document.querySelectorAll("[class*=text-dark]");
        elements.forEach(element => {
            element.classList.replace('bg-light', 'bg-dark')
        });
        elementsDark.forEach(element => {
            element.classList.replace('text-dark', 'text-light')
        });
    } else {
        const elementsLight = document.querySelectorAll("[class*=text-light]");
        const elementsDark = document.querySelectorAll("[class*=bg-dark]");
        elementsDark.forEach(element => {
            element.classList.replace('bg-dark', 'bg-light')
        });
        elementsLight.forEach(element => {
            element.classList.replace('text-light', 'text-dark')
        })
    }
    
}