import React, { createContext, useState } from 'react';

export const CurrentUserContext = createContext([{}, () => {}])

export const CurrentUserProvider = ({children}) => {
  const [state, setState] = useState({
    isEditing: false,
    isCalculating: false
  })
    return (
      <CurrentUserContext.Provider value={[state, setState]}>
        {children}
      </CurrentUserContext.Provider>
    );
  }
