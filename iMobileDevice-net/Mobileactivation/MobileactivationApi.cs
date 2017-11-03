// <copyright file="MobileactivationApi.cs" company="Quamotion">
// Copyright (c) 2016-2017 Quamotion. All rights reserved.
// </copyright>

namespace iMobileDevice.Mobileactivation
{
    using System.Runtime.InteropServices;
    using System.Diagnostics;
    using iMobileDevice.iDevice;
    using iMobileDevice.Lockdown;
    using iMobileDevice.Afc;
    using iMobileDevice.Plist;
    
    
    public partial class MobileactivationApi : IMobileactivationApi
    {
        
        /// <summary>
        /// Backing field for the <see cref="Parent"/> property
        /// </summary>
        private ILibiMobileDevice parent;
        
        /// <summary>
        /// Initializes a new instance of the <see cref"MobileactivationApi"/> class
        /// </summary>
        /// <param name="parent">
        /// The <see cref="ILibiMobileDeviceApi"/> which owns this <see cref="Mobileactivation"/>.
        /// </summary>
        public MobileactivationApi(ILibiMobileDevice parent)
        {
            this.parent = parent;
        }
        
        /// <inheritdoc/>
        public ILibiMobileDevice Parent
        {
            get
            {
                return this.parent;
            }
        }
        
        /// <summary>
        /// Connects to the mobileactivation service on the specified device.
        /// </summary>
        /// <param name="device">
        /// The device to connect to.
        /// </param>
        /// <param name="service">
        /// The service descriptor returned by lockdownd_start_service.
        /// </param>
        /// <param name="client">
        /// Reference that will point to a newly allocated
        /// mobileactivation_client_t upon successful return.
        /// </param>
        /// <returns>
        /// MOBILEACTIVATION_E_SUCCESS on success,
        /// MOBILEACTIVATION_E_INVALID_ARG when one of the parameters is invalid,
        /// or MOBILEACTIVATION_E_MUX_ERROR when the connection failed.
        /// </returns>
        public virtual MobileactivationError mobileactivation_client_new(iDeviceHandle device, LockdownServiceDescriptorHandle service, out MobileactivationClientHandle client)
        {
            MobileactivationError returnValue;
            returnValue = MobileactivationNativeMethods.mobileactivation_client_new(device, service, out client);
            client.Api = this.Parent;
            return returnValue;
        }
        
        /// <summary>
        /// Starts a new mobileactivation service on the specified device and connects to it.
        /// </summary>
        /// <param name="device">
        /// The device to connect to.
        /// </param>
        /// <param name="client">
        /// Pointer that will point to a newly allocated
        /// mobileactivation_client_t upon successful return. Must be freed using
        /// mobileactivation_client_free() after use.
        /// </param>
        /// <param name="label">
        /// The label to use for communication. Usually the program name.
        /// Pass NULL to disable sending the label in requests to lockdownd.
        /// </param>
        /// <returns>
        /// MOBILEACTIVATION_E_SUCCESS on success, or an MOBILEACTIVATION_E_*
        /// error code otherwise.
        /// </returns>
        public virtual MobileactivationError mobileactivation_client_start_service(iDeviceHandle device, out MobileactivationClientHandle client, string label)
        {
            MobileactivationError returnValue;
            returnValue = MobileactivationNativeMethods.mobileactivation_client_start_service(device, out client, label);
            client.Api = this.Parent;
            return returnValue;
        }
        
        /// <summary>
        /// Disconnects a mobileactivation client from the device and frees up the
        /// mobileactivation client data.
        /// </summary>
        /// <param name="client">
        /// The mobileactivation client to disconnect and free.
        /// </param>
        /// <returns>
        /// MOBILEACTIVATION_E_SUCCESS on success,
        /// MOBILEACTIVATION_E_INVALID_ARG when one of client or client->parent
        /// is invalid, or MOBILEACTIVATION_E_UNKNOWN_ERROR when the was an
        /// error freeing the parent property_list_service client.
        /// </returns>
        public virtual MobileactivationError mobileactivation_client_free(System.IntPtr client)
        {
            return MobileactivationNativeMethods.mobileactivation_client_free(client);
        }
        
        /// <summary>
        /// Retrieves the device's activation state.
        /// </summary>
        /// <param name="client">
        /// The mobileactivation client.
        /// </param>
        /// <param name="state">
        /// Pointer to a plist_t variable that will be set to the
        /// activation state reported by the mobileactivation service. The
        /// consumer is responsible for freeing the returned object using
        /// plist_free().
        /// </param>
        /// <returns>
        /// MOBILEACTIVATION_E_SUCCESS on success, or an MOBILEACTIVATION_E_*
        /// error code otherwise.
        /// </returns>
        public virtual MobileactivationError mobileactivation_get_activation_state(MobileactivationClientHandle client, out PlistHandle state)
        {
            MobileactivationError returnValue;
            returnValue = MobileactivationNativeMethods.mobileactivation_get_activation_state(client, out state);
            state.Api = this.Parent;
            return returnValue;
        }
        
        /// <summary>
        /// Retrieves a session blob required for 'drmHandshake' via albert.apple.com.
        /// </summary>
        /// <param name="client">
        /// The mobileactivation client
        /// </param>
        /// <param name="blob">
        /// Pointer to a plist_t variable that will be set to the
        /// session blob created by the mobielactivation service. The
        /// consumer is responsible for freeing the returned object using
        /// plist_free().
        /// </param>
        /// <returns>
        /// MOBILEACTIVATION_E_SUCCESS on success, or an MOBILEACTIVATION_E_*
        /// error code otherwise.
        /// </returns>
        public virtual MobileactivationError mobileactivation_create_activation_session_info(MobileactivationClientHandle client, out PlistHandle blob)
        {
            MobileactivationError returnValue;
            returnValue = MobileactivationNativeMethods.mobileactivation_create_activation_session_info(client, out blob);
            blob.Api = this.Parent;
            return returnValue;
        }
        
        /// <summary>
        /// Retrieves the activation info required for device activation.
        /// </summary>
        /// <param name="client">
        /// The mobileactivation client
        /// </param>
        /// <param name="info">
        /// Pointer to a plist_t variable that will be set to the
        /// activation info created by the mobileactivation service. The
        /// consumer is responsible for freeing the returned object using
        /// plist_free().
        /// </param>
        /// <returns>
        /// MOBILEACTIVATION_E_SUCCESS on success, or an MOBILEACTIVATION_E_*
        /// error code otherwise.
        /// </returns>
        public virtual MobileactivationError mobileactivation_create_activation_info(MobileactivationClientHandle client, out PlistHandle info)
        {
            MobileactivationError returnValue;
            returnValue = MobileactivationNativeMethods.mobileactivation_create_activation_info(client, out info);
            info.Api = this.Parent;
            return returnValue;
        }
        
        /// <summary>
        /// Retrieves the activation info required for device activation in 'session'
        /// mode. This function expects a handshake result retrieved from
        /// https://albert.apple.com/deviceservies/drmHandshake  with a blob
        /// provided by mobileactivation_create_activation_session_info().
        /// </summary>
        /// <param name="client">
        /// The mobileactivation client
        /// </param>
        /// <param name="handshake_result">
        /// The handshake result returned from drmHandshake
        /// </param>
        /// <param name="info">
        /// Pointer to a plist_t variable that will be set to the
        /// activation info created by the mobileactivation service. The
        /// consumer is responsible for freeing the returned object using
        /// plist_free().
        /// </param>
        /// <returns>
        /// MOBILEACTIVATION_E_SUCCESS on success, or an MOBILEACTIVATION_E_*
        /// error code otherwise.
        /// </returns>
        public virtual MobileactivationError mobileactivation_create_activation_info_with_session(MobileactivationClientHandle client, PlistHandle handshakeResult, out PlistHandle info)
        {
            MobileactivationError returnValue;
            returnValue = MobileactivationNativeMethods.mobileactivation_create_activation_info_with_session(client, handshakeResult, out info);
            info.Api = this.Parent;
            return returnValue;
        }
        
        /// <summary>
        /// Activates the device with the given activation record.
        /// The activation record plist dictionary must be obtained using the
        /// activation protocol requesting from Apple's https webservice.
        /// </summary>
        /// <param name="client">
        /// The mobileactivation client
        /// </param>
        /// <param name="activation_record">
        /// The activation record plist dictionary
        /// </param>
        /// <returns>
        /// MOBILEACTIVATION_E_SUCCESS on success, or an MOBILEACTIVATION_E_*
        /// error code otherwise.
        /// </returns>
        public virtual MobileactivationError mobileactivation_activate(MobileactivationClientHandle client, PlistHandle activationRecord)
        {
            return MobileactivationNativeMethods.mobileactivation_activate(client, activationRecord);
        }
        
        /// <summary>
        /// Activates the device with the given activation record in 'session' mode.
        /// The activation record plist dictionary must be obtained using the
        /// activation protocol requesting from Apple's https webservice.
        /// </summary>
        /// <param name="client">
        /// The mobileactivation client
        /// </param>
        /// <param name="activation_record">
        /// The activation record plist dictionary
        /// </param>
        /// <returns>
        /// MOBILEACTIVATION_E_SUCCESS on success, or an MOBILEACTIVATION_E_*
        /// error code otherwise.
        /// </returns>
        public virtual MobileactivationError mobileactivation_activate_with_session(MobileactivationClientHandle client, PlistHandle activationRecord)
        {
            return MobileactivationNativeMethods.mobileactivation_activate_with_session(client, activationRecord);
        }
        
        /// <summary>
        /// Deactivates the device.
        /// </summary>
        /// <param name="client">
        /// The mobileactivation client
        /// </param>
        public virtual MobileactivationError mobileactivation_deactivate(MobileactivationClientHandle client)
        {
            return MobileactivationNativeMethods.mobileactivation_deactivate(client);
        }
    }
}
