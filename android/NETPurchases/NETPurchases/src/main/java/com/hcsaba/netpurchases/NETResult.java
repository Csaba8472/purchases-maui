package com.hcsaba.netpurchases;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;

public interface NETResult {

    void success(@Nullable Object result);

    void error(@NonNull String errorCode, @Nullable String errorMessage, @Nullable Object errorDetails);

    /** Handles a call to an unimplemented method. */
    void notImplemented();
}
