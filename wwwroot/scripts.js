function toggleDarkMode() {
    const elements = document.querySelectorAll("[class*=bg-light]");
    if (elements.length > 0){
        const boxes = document.querySelectorAll('[id*=box]');
        const elementsDark = document.querySelectorAll("[class*=text-dark]");
        elements.forEach(element => {
            element.classList.replace('bg-light', 'bg-dark')
        });
        elementsDark.forEach(element => {
            element.classList.replace('text-dark', 'text-light')
        });
        boxes.forEach(element => {
            if (element.classList.contains('bg-white')){
                element.classList.replace('bg-white', 'bg-black')
            } else {
                element.classList.replace('bg-black', 'bg-white')
            }
        })
    } else {
        const elementsLight = document.querySelectorAll("[class*=text-light]");
        const elementsDark = document.querySelectorAll("[class*=bg-dark]");
        const boxes = document.querySelectorAll('[id*=box]');
        elementsDark.forEach(element => {
            element.classList.replace('bg-dark', 'bg-light')
        });
        elementsLight.forEach(element => {
            element.classList.replace('text-light', 'text-dark')
        })
        boxes.forEach(element => {
            if (element.classList.contains('bg-white')){
                element.classList.replace('bg-white', 'bg-black')
            } else {
                element.classList.replace('bg-black', 'bg-white')
            }
        })
    }
    
}