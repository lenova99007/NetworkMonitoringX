const domContentLoadedCallbacks = [];
const onDOMContentLoaded = (callback) => {
    if (document.readyState === 'loading') {
        // add listener on the first call when the document is in loading state
        if (!domContentLoadedCallbacks.length) {
            document.addEventListener('DOMContentLoaded', () => {
                for (const callback of domContentLoadedCallbacks) {
                    callback();
                }
            });
        }
        domContentLoadedCallbacks.push(callback);
    }
    else {
        callback();
    }
};
/* ES2022 UTILITY FUNCTIONS */
/**
 * Check if an element has a specific data attribute using ES2022 Object.hasOwn()
 */
const hasDataAttribute = (element, attribute) => {
    return Object.hasOwn(element.dataset, attribute);
};
/**
 * Get the last element from a NodeList using ES2022 Array.at()
 */
const getLastElement = (elements) => {
    const elementsArray = Array.from(elements);
    return elementsArray.at(-1);
};
/**
 * Safe property access with better error handling
 */
const safePropertyAccess = (obj, property) => {
    try {
        return Object.hasOwn(obj, property) ? obj[property] : undefined;
    }
    catch (error) {
        // ES2022 Error cause
        throw new Error(`Failed to access property '${property}'`, { cause: error });
    }
};
/* SLIDE UP */
const slideUp = (target, duration = 500) => {
    target.style.transitionProperty = 'height, margin, padding';
    target.style.transitionDuration = `${duration}ms`;
    target.style.boxSizing = 'border-box';
    target.style.height = `${target.offsetHeight}px`;
    target.style.overflow = 'hidden';
    globalThis.setTimeout(() => {
        target.style.height = '0';
        target.style.paddingTop = '0';
        target.style.paddingBottom = '0';
        target.style.marginTop = '0';
        target.style.marginBottom = '0';
    }, 1);
    globalThis.setTimeout(() => {
        target.style.display = 'none';
        target.style.removeProperty('height');
        target.style.removeProperty('padding-top');
        target.style.removeProperty('padding-bottom');
        target.style.removeProperty('margin-top');
        target.style.removeProperty('margin-bottom');
        target.style.removeProperty('overflow');
        target.style.removeProperty('transition-duration');
        target.style.removeProperty('transition-property');
    }, duration);
};
/* SLIDE DOWN */
const slideDown = (target, duration = 500) => {
    target.style.removeProperty('display');
    let { display } = globalThis.getComputedStyle(target);
    if (display === 'none') {
        display = 'block';
    }
    target.style.display = display;
    const height = target.offsetHeight;
    target.style.overflow = 'hidden';
    target.style.height = '0';
    target.style.paddingTop = '0';
    target.style.paddingBottom = '0';
    target.style.marginTop = '0';
    target.style.marginBottom = '0';
    globalThis.setTimeout(() => {
        target.style.boxSizing = 'border-box';
        target.style.transitionProperty = 'height, margin, padding';
        target.style.transitionDuration = `${duration}ms`;
        target.style.height = `${height}px`;
        target.style.removeProperty('padding-top');
        target.style.removeProperty('padding-bottom');
        target.style.removeProperty('margin-top');
        target.style.removeProperty('margin-bottom');
    }, 1);
    globalThis.setTimeout(() => {
        target.style.removeProperty('height');
        target.style.removeProperty('overflow');
        target.style.removeProperty('transition-duration');
        target.style.removeProperty('transition-property');
    }, duration);
};
/* TOGGLE */
const slideToggle = (target, duration = 500) => {
    if (globalThis.getComputedStyle(target).display === 'none') {
        slideDown(target, duration);
        return;
    }
    slideUp(target, duration);
};
export { onDOMContentLoaded, slideUp, slideDown, slideToggle, hasDataAttribute, getLastElement, safePropertyAccess };
